import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'https://localhost:44393',
});

export default axiosInstance;