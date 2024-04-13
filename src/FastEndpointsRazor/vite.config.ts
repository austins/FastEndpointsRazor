import { defineConfig } from "vite";

export default defineConfig({
    build: {
        outDir: "./wwwroot/assets",
        emptyOutDir: true,
        rollupOptions: {
            input: {
                "app": "./Assets/app.ts",
                "app.css": "./Assets/app.css"
            },
            output: {
                assetFileNames: "[name][extname]",
                chunkFileNames: "[name].js",
                entryFileNames: "[name].js"
            }
        }
    }
});
