import { FC } from "react"
import clsx from "clsx"

type PageSwitchProps = {
   perPage: number
   total: number
   onChange(page: number): void
   current: number
}

export const PageSwitch: FC<PageSwitchProps> = ({ perPage, total, onChange, current }) => {
   
   const pages = new Array(Math.ceil(total / perPage)).fill(0)

   const handleClick = (page: number) => {
      onChange(page)
      scrollTo(0, 0)
   }

   return (
      <div className="h-96 flex items-center space-x-2 justify-center">
         {pages.map((_, index) => (
            <button
               key={index}
               onClick={() => handleClick(index + 1)}
               className={clsx("w-12 h-12 rounded-lg bg-green-100 border-2 border-green-400", { "!bg-orange-50": current === index + 1 })}
            >
               {index + 1}
            </button>
         ))}
      </div>
   )
}
