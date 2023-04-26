const button = document.querySelector('.header__button');
const menu = document.querySelector('.menu');

button.addEventListener('click', openMenu);

function openMenu(){
    menu.classList.toggle('menu-open');
}
