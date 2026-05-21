
function setLang(lang) {
    if (lang === 'fa') {
        document.documentElement.lang = 'fa';
        document.documentElement.dir = 'rtl';
    } else {
        document.documentElement.lang = 'en';
        document.documentElement.dir = 'ltr';
    }
}
