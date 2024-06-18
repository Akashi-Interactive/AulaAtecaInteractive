mergeInto(LibraryManager.library, {
    OpenInNewTabWebGL: function(url) {
        var win = window.open(url, '_blank');
        win.focus();
    }
});
