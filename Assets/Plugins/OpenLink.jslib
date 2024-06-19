// Agrega este script en el archivo index.html de la build de WebGL
<script type='text/javascript'>
    var LibraryManager = {
        library: {
            OpenInNewTabWebGL: function(url) {
                var win = window.open(Pointer_stringify(url), '_blank');
                if (win) {
                    win.focus();
                } else {
                    console.error('Could not open new tab');
                }
            }
        }
    };

    mergeInto(LibraryManager.library, LibraryManager.library);
</script>
