export function initializeSplashPageListener() {

    const elem = document.querySelector(".parallax");
    if (elem != null) {
        document.addEventListener("mousemove", parallax);
        function parallax(e) {
            let w = window.innerWidth / 2;
            let h = window.innerHeight / 2;
            let mouseX = e.clientX;
            let mouseY = e.clientY;
            let depth1 = `${50 + (mouseX - w) * 0.01}% ${50 + (mouseY - h) * 0.02}%`;
            let depth2 = `${50 + (mouseX - w) * 0.02}% ${50 + (mouseY - h) * 0.04}%`;
            let depth3 = `${50 + (mouseX - w) * 0.04}% ${50 + (mouseY - h) * 0.08}%`;
            let x = `${depth3},${depth2},${depth1}`;

            elem.style.backgroundPosition = x;
        }
    }    
}