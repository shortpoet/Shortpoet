export default colorLog = (message, color, background) => {
  color = color || "black";
  if (background) {
    console.log(`%c` + `${message}`, `color:` + `${color};background:${background}`)
  } else {
    console.log(`%c` + `${message}`, `color:` + `${color}`)
  }
}
