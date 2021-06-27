var express = require('express');
var router = express.Router();
var multipart = require('connect-multiparty');
var multipart_middleware = multipart();
let controller = require('../controller/StudentController');

router.get('/', function (req, res, next) {
    controller.list(req, res);
});

router.get('/show/:id', function (req, res, next) {
    controller.show(req, res);
});

router.post('/', multipart_middleware, function (req, res) {
    controller.store(req, res, multipart_middleware);
});

router.put('/', multipart_middleware, function (req, res) {
    controller.edit(req, res, multipart_middleware);
});

router.delete('/:id', function (req, res) {
    controller.delete(req, res);
})

module.exports = router;