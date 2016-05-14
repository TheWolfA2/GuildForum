$(document).ready(function () {
    $("textarea.mdd_editor").MarkdownDeep({
        disableTabHandling: true,
        help_location: "/Content/mdd_help.htm",
        resizebar: false,
        SafeMode: true,
    });
});