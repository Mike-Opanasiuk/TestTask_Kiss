import { FC, useEffect, useState } from "react"
import { Grid } from "../../components/layout/grid/Grid"
import { PageSwitch } from "../../components/layout/page-switch/PageSwitch"
import { httpClient } from "../../core/http/client"
import { settings } from "../../settings"
import { TImagesResponse } from "../../types/images-response"

export const HistoryPage: FC = () => {

   const perPage = settings.images.perPage
   
   const [page, setPage] = useState(1)

   const [imagesResponse, setImagesResponse] = useState<TImagesResponse>()

   const total = imagesResponse?.totalCount || 0

   useEffect(() => {
      httpClient.get<TImagesResponse>(settings.apiUrl + `/images/visited-images?page=${page}&perPage=${perPage}`).then((response) => {
         setImagesResponse(response.data)
      })
   }, [page])

   return (
      <>
         <Grid images={imagesResponse?.images || []} />
         <PageSwitch
            total={total}
            perPage={perPage}
            current={page}
            onChange={setPage}
         />
      </>
   )
}
