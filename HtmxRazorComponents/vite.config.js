import { defineConfig } from "vite";
import tailwindcss from "@tailwindcss/vite";

export default defineConfig({
  plugins: [tailwindcss()],
  build: {
    outDir: "wwwroot/dist",
    assetsDir: "",
    emptyOutDir: true,
    manifest: true,
    rollupOptions: {
      input: "Styles/app.css",
    },
  },
});
