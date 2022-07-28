const loadCollection = (userId) => {
    if (userId)
        window.location.href = window.location.pathname + '?artistId=' + userId
}
window.onload = () => {
    const params = new URLSearchParams(window.location.search);
    document.getElementById("selectedArtist").value = params.get('artistId')
}