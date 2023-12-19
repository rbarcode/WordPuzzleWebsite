document.querySelector(".register-link").onclick = () => {
    let wrapper = document.querySelector(".wrapper");
    wrapper.classList.add("active");
}


document.querySelector(".login-link").onclick = () => {
    let wrapper = document.querySelector(".wrapper");
    wrapper.classList.remove("active");
}