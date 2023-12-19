import { FC, MouseEvent } from "react"

type ImagePreviewProps = {
   src: string
   onClose(): void
}

export const ImagePreview: FC<ImagePreviewProps> = ({ src, onClose }) => {

   const handleClickOutside = (event: MouseEvent) => {
      if (event.target === event.currentTarget) {
         onClose()
      }
   }

   return (
      <div onClick={handleClickOutside} className="fixed w-full h-full left-0 top-0 bg-black/50 flex">
         <img src={src} className="w-96 h-96 m-auto hover:scale-150 transition" />
      </div>
   )
}
