const buy = (songId) => {
    fetch('Store/Buy?songId=' + songId)
        .then(response => {
            if (response.ok) {
                window.location.reload();
            }
            else if (response.status === 402) {
                alert('Insufficient funds')
            }
            else {
                alert('Something went wrong')
            }
        })
}

const refund = (songId) => {
    fetch('Store/Refund?songId=' + songId).then(response => {
        if (response.ok) {
            window.location.reload();
        }
        else {
            alert('Something went wrong')
        }
    })
}