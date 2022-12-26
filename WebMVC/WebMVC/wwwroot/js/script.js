﻿
$(document).ready(function () {

    var arrLang = {

        'tr': {

            '0': 'Blog Ekleme Sayfası',
            '1': 'Ekle',
            '2': 'Geri Dön',
            '3': 'Düzenle',
            '4': 'Düzenle',
            '5': 'Sil',
            '6': 'Blog Ekle',
            '7': 'Role',
            '8': 'Gir',
            '9': 'Hesap Oluştur',
            '10': 'Satın al',
            '11': "Sat",
            '12': "Güç",
            '13': 'Yaş',
            '14': 'Tür',
            '15': 'Fiyat',
            '16': 'Yorum at',
            '17': 'Kaldır',
            '18': 'Güncelle',
            '19': 'Yeni Pokemon Ekle',
            '20': 'Pokemon Oluştur',
            '21': 'Pokemon Güncelle',
            '22': 'Kullanıcı getir',
            '23': 'Pokemonları',
            '24': 'Çıkış Yap',
            '25': 'Markette',
            '26': 'Satıcı',
        },


        'en': {
            '0': 'Blog Add Page',
            '1': 'Add',
            '2': 'Back',
            '3': 'Edit',
            '4': 'Edit',
            '5': 'Delete',
            '6': 'Add Blog',
            '7': 'Role',
            '8': 'Login',
            '9': 'Create Account',
            '10': 'Buy',
            '11': 'Sell',
            '12': 'Power',
            '13': 'Age',
            '14': 'Species',
            '15': 'Price',
            '16': 'Add a Note',
            '17': 'Remove',
            '18': 'Update',
            '19': 'Add New Pokemon',
            '20': 'Create Pokemon',
            '21': 'Update Pokemon',
            '22': 'Get User',
            '23': "'s Pokemons",
            '24': 'Log Out',
            '25': 'At Market',
            '26': 'Seller',
        },


    };



    $('.dropdown-item').click(function () {
        localStorage.setItem('dil', JSON.stringify($(this).attr('id')));
        location.reload();
    });

    var lang = JSON.parse(localStorage.getItem('dil'));

    if (lang == "en") {
        $("#drop_yazı").html("English");
    }
    else {
        $("#drop_yazı").html("Türkçe");

    }

    $('a,h5,p,h1,h2,span,li,button,h3,label').each(function (index, element) {
        $(this).text(arrLang[lang][$(this).attr('key')]);

    });

});