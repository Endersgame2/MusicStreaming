const loadCollection = (userId) => {
    if (userId)
        window.location.href = window.location.pathname + '?userId=' + userId
}
window.onload = () => {
    const params = new URLSearchParams(window.location.search);
    document.getElementById("selectedUser").value = params.get('userId')
}