import axios from "axios"
import cookie from "js-cookie"
import { settings } from "../../settings"

export const httpClient = axios.create({
   baseURL: settings.apiUrl,
})

httpClient.interceptors.request.use((config) => {
   const token = cookie.get(settings.cookies.token)
   config.headers.Authorization = token
   return config
})
