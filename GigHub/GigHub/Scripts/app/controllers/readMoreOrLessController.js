var ReadMoreOrLessController = function (container, panel) {

    var readMoreHtml = $(panel).html();
    var lessText = readMoreHtml.replace(/^([\s\S]{150}\S*)[\s\S]*/, "$1");

    var showMore = function (event) {
        event.preventDefault();

        $(this).parent(panel).html(readMoreHtml)
            .append("<a href='' class='show-less-link'> show less</a>");
    }

    var readLess = function (event) {
        event.preventDefault();

        $(this).parent(panel).html(lessText)
            .append("<a href='' class='read-more-link'> read more</a>");
    }

    if (readMoreHtml.length > 100) {
        $(panel).html(lessText)
            .append("<a href='' class='read-more-link'> show more</a>");
    } else {
        $(panel).html(readMoreHtml);
    }

    $(container).on("click", ".read-more-link", showMore);
    $(container).on("click", ".show-less-link", readLess);
}