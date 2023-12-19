const wrapper = document.querySelector(".wrapper");
const loginLink = document.querySelector(".login-link");
const registerLink = document.querySelector(".register-link");

registerLink.onclick = () => {
    wrapper.classList.add("active");
}


loginLink.onclick = () => {
    wrapper.classList.remove("active");
}