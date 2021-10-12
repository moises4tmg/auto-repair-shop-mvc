// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//CleaveJS: Customização de input para número de telefone
document.querySelectorAll('.input-fone').forEach(function(field) {
    new Cleave(field, {
      numericOnly: true,
      phone: true,
      phoneRegionCode: 'BR'
    });
});


//CleaveJS: Customização de input para número de CPF
document.querySelectorAll('.input-cpf').forEach(function(field) {
    new Cleave(field, {
        numericOnly: true,
        blocks: [3, 3, 3, 2],
        delimiters: ['.', '.', '-']
    });
});


//CleaveJS: Customização de input para CEP
document.querySelectorAll('.input-cep').forEach(function(field) {
    new Cleave(field, {
        numericOnly: true,
        blocks: [5, 3],
        delimiter: '-'
    });
});


//CleaveJS: Customização de input para Placa
document.querySelectorAll('.input-placa').forEach(function(field) {
    new Cleave(field, {
        blocks: [3, 4],
        delimiter: '-'
    });
});


//CleaveJS: Customização de input para Preco
document.querySelectorAll('.input-preco').forEach(function(field) {
    new Cleave(field, {
        numeral: true,
        numeralDecimalMark: ',',
        delimiter: '.'
    });
});
