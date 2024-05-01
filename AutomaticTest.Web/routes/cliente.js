var express = require('express');
var router = express.Router();

router.get('/', function(req, res, next) {
    res.render('cliente', { title: 'Cliente' });
});

router.post('/', function (req, res, next) {
    res.render('clientes', { title: 'Cliente' });
});

router.get('/:id', function (req, res, next) {
    res.render('cliente', { title: 'Cliente' });
});

module.exports = router;
