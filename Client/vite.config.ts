import { defineConfig } from "vite"
import react from "@vitejs/plugin-react-swc"

export default defineConfig({
   envPrefix: "APP_",
   server: {
      port: 3000,
   },
   plugins: [react()],
})
