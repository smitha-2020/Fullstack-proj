import axios from "axios";

const axiosInstance = axios.create({
    baseURL: "https://localhost:5001/"
})

export default axiosInstance