const tBody = document.querySelector("tbody")

async function getAgencias() {
    let response = await fetch("http://localhost:5000/api/agencias")
    return response.json()
}

async function main() {
    agencias = await getAgencias()

    console.log(agencias)

    agencias.forEach(a => {
        const tr = document.createElement("tr")

        const tdId = document.createElement("td")
        tdId.textContent = a.id
        tr.appendChild(tdId)

        const tdName = document.createElement("td")
        tdName.textContent = a.name
        tr.appendChild(tdName)

        const tdCity = document.createElement("td")
        tdCity.textContent = a.city
        tr.appendChild(tdCity)

        const tdState = document.createElement("td")
        tdState.textContent = a.state
        tr.appendChild(tdState)

        const tdEdit = document.createElement("td")
        tdEdit.style.backgroundColor = "Blue"
        tdEdit.addEventListener("click", () => {
            localStorage.setItem("toEditId", a.id)
            window.location.href = "./edit.html"
        })
        tr.appendChild(tdEdit)

        const tdDelete = document.createElement("td")
        tdDelete.style.backgroundColor = "Red"
        tdDelete.addEventListener("click", async () => {
            await fetch("http://localhost:5000/api/agencias/" + a.id, {
                "method": "DELETE"
            })
            tBody.removeChild(tr)
        })
        tr.appendChild(tdDelete)

        tBody.appendChild(tr)
    });
}

main()