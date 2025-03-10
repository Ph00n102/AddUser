window.playaudio = (sound, id) => {
    var audioPlayer = new Audio(sound);
    audioPlayer.onended = () => {
        if (id !== "") {
            document.getElementById(id)?.classList.remove('highlight');
        }
    };
    audioPlayer.play();
    console.log('play ' + sound);
    if (id !== "") {
        document.getElementById(id)?.classList.add('highlight');
    }
};