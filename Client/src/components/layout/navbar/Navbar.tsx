import { FC } from "react"
import { Link, useLocation } from "react-router-dom"
import clsx from "clsx"
import { useAuth } from "../../../core/auth/useAuth"

export const Navbar: FC = () => {

   const { pathname } = useLocation()
   const { authorized, logOut } = useAuth()

   return (
      <header className="h-24 flex items-center px-12">
         <div className="space-x-8">
            <Link to="/" className={clsx({ "underline": pathname === "/" })}>
               Home
            </Link>
            {authorized && (
               <Link to="/images" className={clsx({ "underline": pathname === "/images" })}>
                  Images
               </Link>
            )}
            {authorized && (
               <Link to="/history" className={clsx({ "underline": pathname === "/history" })}>
                  History
               </Link>
            )}
         </div>

         {authorized && (
            <div className="ml-auto flex items-center">
               <button onClick={logOut} className="w-20 h-12 bg-gray-50 shadow border-black rounded">
                  Log out
               </button>
            </div>
         )}
      </header>
   )
}
