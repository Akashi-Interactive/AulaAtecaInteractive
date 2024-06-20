mergeInto(LibraryManager.library, {
    OpenInNewTabWebGL: function (url) {
        var win = window.open(Pointer_stringify(url), '_blank');
        if (win) {
            win.focus();
        } else {
            console.error('Could not open new tab');
        }
    }
});
