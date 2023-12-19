import { FC } from "react"
import { TImage } from "../../../types/image"
import { httpClient } from "../../../core/http/client"

type GridProps = {
   images: TImage[]
}

export const Grid: FC<GridProps> = ({ images }) => {

   const visitPage = (imgUrl: string) => {
      httpClient.post("/images/visit-image", imgUrl, { "headers": { "Content-Type": "application/json" } })
      window.open(imgUrl, "_blank", "noopener,noreferrer")
   }

   return (
      <>
         <div className="grid grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-4">
            {images.map((item, index) => (
               <div onClick={() => visitPage(item.localUrl)} key={index}>
                  <img className="object-cover h-full w-full" src={item.localUrl} />
               </div>
            ))}
         </div>
      </>
   )
}
