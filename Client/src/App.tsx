import { FC } from "react"
import { Routes, Route } from "react-router-dom"
import { Navbar } from "./components/layout/navbar/Navbar"

import { HomePage } from "./pages/home/HomePage"
import { ImagesPage } from "./pages/images/ImagesPage"
import { HistoryPage } from "./pages/history/HistoryPage"
import { useAuth } from "./core/auth/useAuth"

export const App: FC = () => {

   const { authorized } = useAuth()

   return (
      <div className="h-full px-8 md:px-16 lg:px-32 xl:px-64">
         <Navbar />
         <main>
            <Routes>
               <Route path="/" element={<HomePage />} />
               {authorized && <Route path="/images" element={<ImagesPage />} />}
               {authorized && <Route path="/history" element={<HistoryPage />} />}
            </Routes>
         </main>
      </div>
   )
}
