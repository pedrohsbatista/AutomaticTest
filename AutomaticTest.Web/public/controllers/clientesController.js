import serviceIndexDB from '../services/serviceIndexDB.js';

const objectStoreName = 'cliente';

window.onload = function () {          
    getAll();
}

function getAll() {
    serviceIndexDB.getAll(objectStoreName).then((result) => {
        let element = document.getElementsByTagName("tbody")[0];
        result.forEach(function (item) {
            let tr = document.createElement('tr');
            tr.id = item.id
            tr.innerHTML = `<td>${item.nome}</td>
                            <td>${item.email}</td>
                            <td>${item.dataNascimento ? new Date(item.dataNascimento).toLocaleDateString('pt-BR', { timeZone: 'UTC' }) : ''}</td>
                            <td>${item.telefoneCelular}</td>                            
                            <td>
                              <button type="button" class="btn btn-sm btn-success" onclick="edit('${item.id}')">Editar</button>
                              <button type="button" class="btn btn-sm btn-danger" onclick="deleteById('${item.id}')">Deletar</button>
                            </td>`;
            element.appendChild(tr);
        });
    }).catch((error) => {
        alert(error)
    });
}

window.edit = function (id) {
    window.location.pathname = `/cliente/?id='${id}'`;
}

window.deleteById = function(id) {
    serviceIndexDB.delete(objectStoreName, id).then((result) => {
        var element = document.getElementById(id);
        element.remove();
    }).catch((error) => {
        alert(error);
    })
}