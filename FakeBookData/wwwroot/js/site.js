$(function () {
	let pageNumber = 0;
	const defaultImage = "https://fastly.picsum.photos/id/386/240/320.jpg?hmac=v7pKDT-lq5Rc_rtX2aJRj32yy6BpYIvVi_S7vNU1dgg";
	const toolbar = $(".toolbar");
	const tools = $(".toolbar-tool");
	const seedInput = $(".seed-input");
	const shuffleSeedButton = $(".seed-shuffle-button");
	const likesInput = $(".likes-input");
	const likesOutput = $(".likes-output");
	const bookList = $(".book-list");
	const bookRows = $(".book-info-row");
	const coverImages = $(".book-cover-image");
	const intersectionTarget = $("#intersection-target");
	const spinner = $(".spinner");

	const intersectionHandler = function (entries, observer) {
		entries.forEach((entry) => {
			if (entry.isIntersecting) {
				spinner.show();
				pageNumber++;
				fetchBooks(10, pageNumber).then((books) => {
					const jBooks = $(books);

					$(".book-info-row", jBooks).on("click", bookRowClickHandler);
					handleImageLoad($(".book-cover-image", jBooks));

					bookList.append(jBooks);
					spinner.hide();
				});
			}
		});
	}

	const bookRowClickHandler = function (e) {
		$(e.currentTarget).next().slideToggle({
			duration: 400,
			easing: "linear",
			start: function () {
				$(this).css('display', 'flex');
			}
		});
	}
	const handleImageLoad = function (images) {
		setTimeout(() => {
			images.each((i, image) => {
				if (image.naturalWidth === 0) {
					$(image).attr("src", defaultImage);
				};
			});
		}, 5000);
	}

	handleImageLoad(coverImages);

	tools.on("change", function () {
		pageNumber = 0;
		fetchBooks(20, pageNumber).then((books) => {
			const jBooks = $(books);
			$(".book-info-row", jBooks).on("click", bookRowClickHandler);
			handleImageLoad($(".book-cover-image", jBooks));

			bookList.empty();
			intersectionTarget.hide();

			bookList.append(jBooks);
			intersectionTarget.show();
		});
	});

	shuffleSeedButton.on("click", function () {
		seedInput.val(Math.floor(Math.random() * 100000000) + 1);
		seedInput.trigger("change");
	});

	bookRows.on("click", bookRowClickHandler);

	likesInput.on("input", function () {
		likesOutput.text(likesInput.val());
	});

	handleIntersection(intersectionTarget[0], intersectionHandler);
});

function handleIntersection(target, handler) {

	const options = {
		root: null,
		rootMargin: "0px",
		threshold: 1.0
	};

	const observer = new IntersectionObserver(handler, options);
	observer.observe(target);
}

function fetchBooks(bookCount, pageNumber) {
	let startIndex = 1 + pageNumber * 10 + (pageNumber ? 10 : 0);
	const locale = $(".language-select").val();
	const seed = parseInt($(".seed-input").val());
	const likeCount = $(".likes-input").val();
	const reviewCount = $(".reviews-input").val();

	const query = new URLSearchParams({
		StartIndex: startIndex,
		BookCount: bookCount,
		Locale: locale,
		Seed: seed + pageNumber,
		LikeCount: likeCount,
		ReviewCount: reviewCount
	}).toString();


	return fetch("/next?" + query,
		{
			method: "GET",
			headers: {
				"Content-Type": "application/json",
				"Accept": "text/html"
			}
		}).then(res => res.text());
}