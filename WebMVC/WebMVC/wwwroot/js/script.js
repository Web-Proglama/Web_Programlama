
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
            '7': 'Daha Fazla Oku',
            '8': 'Bloglar',
            '9': 'Kullanıcı Adı',
            '10': 'Kayıt Ol',
            '11': "Hesabın Yok Mu?",
            '12': "Adı",
            '13': 'Soy Adı',
            '14': 'Şifre',
            '15': 'Profil Fotoğrafı Seçiniz',
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
            '27': 'Tüm kategoriler',
            '28': 'Kayıt Ol',
            '29': 'Giriş Yap',
            '30': 'Çıkış Yap',
            '31': 'Hoşgeldiniz',
            '32': 'Anasayfa',
            '33': 'Son Postlar',
            '34': 'Kategoriler',
            '35': 'Bloglar',
            '36': 'Giriş yap',
            '37': 'Şimdi Kayıt Ol'

        },


        'en': {
            '0': 'Blog Add Page',
            '1': 'Add',
            '2': 'Back',
            '3': 'Edit',
            '4': 'Edit',
            '5': 'Delete',
            '6': 'Add Blog',
            '7': 'Read More',
            '8': 'Blogs',
            '9': 'User Name',
            '10': 'Sign In',
            '11': 'Don\'t have an account?',
            '12': 'First Name',
            '13': 'Last Name',
            '14': 'Password',
            '15': 'Chose profile photo',
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
            '27': 'All Categories',
            '28': 'Sign In',
            '29': 'Log In',
            '30': 'Log Out',
            '31': 'Welcome',
            '32': 'Home',
            '33': 'Recent Posts',
            '34': 'Categories',
            '35': 'Blog Posts',
            '36': 'Sign In Now',
            '37': 'Register Now'
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

    $('a,h5,h4,p,h1,h2,span,li,button,h3,label').each(function (index, element) {
        $(this).text(arrLang[lang][$(this).attr('key')]);

    });

});