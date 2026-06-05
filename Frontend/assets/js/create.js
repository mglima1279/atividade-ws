const form = document.querySelector("form")

form.addEventListener("submit", async e => {
    e.preventDefault()

    const formData = new FormData(e.target)

    let entityObj = {
        "name": formData.get("name"),
        "city": formData.get("city"),
        "state": formData.get("state"),
    }
    entityObj = JSON.stringify(entityObj)

    let response = await fetch("http://localhost:5000/api/agencias", {
        "method": "POST",
        "headers": { "Content-Type": "application/json" },
        "body": entityObj
    })

    if (response.status == 201) {
        alert("Sucesso")
        window.location.href = "../"
    } else {
        alert("Erro ao tentar criar agencia")
    }
})