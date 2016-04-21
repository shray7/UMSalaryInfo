var backgroundImage = 1;
function changeStyle() {


    if (backgroundImage == 1) {
        $('body').css({ backgroundImage: 'url(content/lawschool.jpg)' });
        backgroundImage = 2;
    }

    else if (backgroundImage == 2) {
        $('body').css({ backgroundImage: 'url(content/hogwarts.jpg)' });
        backgroundImage = 3;
    }

    else if (backgroundImage == 3) {
        $('body').css({ backgroundImage: 'url(content/bschool.jpg)' });
        backgroundImage = 4;
    }

    else if (backgroundImage == 4) {
        $('body').css({ backgroundImage: 'url(content/mstadium.jpg)' });
        backgroundImage = 1;
    }

}