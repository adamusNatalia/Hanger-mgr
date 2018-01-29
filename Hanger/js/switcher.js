$(document).ready(function () {
    $("aside.preview nav").show();
    var previewImg = $("img#main");
    $("a:first").addClass("active");
    $("nav a img").click(function () {
        var link = $(this).parent();
        var linkHref = link.attr("href");
        var linkAlt = link.attr("alt");
        if ($(link).hasClass("active") == false) {
            $("a").removeClass("active");
            link.addClass("active");
            $(previewImg).animate({
                opacity: 0.8,
            }, 300, function () {
                previewImg.attr("src", linkHref);
                previewImg.attr("alt", linkAlt);
                $(this).animate({
                    opacity: 1,
                }, 300
				);
            });
        }
        return false;
    });
    $("input").click(function () {
        $("p.more").fadeIn("slow");
    })
});