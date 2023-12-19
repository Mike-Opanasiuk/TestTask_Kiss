import cookie from "js-cookie"
import { useState } from "react"
import { useNavigate } from "react-router-dom"
import { settings } from "../../settings"

export const useAuth = () => {

   const [accessToken, setAccessToken] = useState(cookie.get(settings.cookies.token))

   const navigate = useNavigate()

   const logOut = () => {
      cookie.remove(settings.cookies.token)
      setAccessToken(undefined)
      navigate("/")
   }

   return {
      authorized: accessToken ? true : false,
      logOut,
   }
}
