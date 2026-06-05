const form = document.querySelector("form")

async function getAgencia() {
    let response = await fetch("http://localhost:5000/api/agencias/" + localStorage.getItem("toEditId"))

    if (response.status == 200) return response.json()
    else {
        alert("ERROR")
        window.location.href = "../"
    }
}

async function main() {
    agencia = await getAgencia()

    const inputs = form.querySelectorAll("input")

    inputs[0].value = agencia.name
    inputs[1].value = agencia.city
    inputs[2].value = agencia.state

    form.addEventListener("submit", async e => {
        e.preventDefault()

        const formData = new FormData(e.target)

        let entityObj = {
            "id": agencia.id,
            "name": formData.get("name"),
            "city": formData.get("city"),
            "state": formData.get("state"),
        }
        entityObj = JSON.stringify(entityObj)

        let response = await fetch("http://localhost:5000/api/agencias/" + localStorage.getItem("toEditId"), {
            "method": "PUT",
            "headers": { "Content-Type": "application/json" },
            "body": entityObj
        })

        if (response.status == 200) {
            alert("Sucesso")
            window.location.href = "../"
        } else {
            console.error(response)
            alert("Erro ao tentar atualizar agencia")
        }
    })
}

main()