import serviceIndexDB from '../services/serviceIndexDB.js';

const objectStoreName = 'cliente';

var id;

window.onload = function()
{
    let url = new URL(decodeURIComponent(window.location.href));    
    if (url.searchParams.size > 0)
    {
        id = url.searchParams.get('id').replaceAll("'", "");
        serviceIndexDB.getById(objectStoreName, id).then((result) => {
            let form = document.getElementById('form');
            form.nome.value = result.nome ?? null;
            form.email.value = result.email ?? null;
            form.dataNascimento.value = result.dataNascimento ?? null;
            form.telefoneCelular.value = result.telefoneCelular ?? null;
        }).catch((error) => {
            alert(error);
        });
    }
}

document.getElementById('form').addEventListener('submit', function (e) {
    e.preventDefault();

    let object = {
        id: id ?? undefined,
        nome: e.currentTarget.nome.value,
        email: e.currentTarget.email.value,
        dataNascimento: e.currentTarget.dataNascimento.value,
        telefoneCelular: e.currentTarget.telefoneCelular.value
    }

    if (object.id) {
        serviceIndexDB.put(objectStoreName, object).then((success) => {
            window.location.pathname = "/clientes";
        }).catch((error) => {
            alert(error);
        });
    }
    else {
        serviceIndexDB.post(objectStoreName, object).then((success) => {
            window.location.pathname = "/clientes";
        }).catch((error) => {
            alert(error);
        });
    }
})