import { type Config } from "tailwindcss";

const config: Config = {
    content: ["./{Layouts,Pages}/**/*.razor",],
    theme: {
        extend: {
            container: { center: true, padding: "1rem" }
        },
    },
    plugins: [],
}

export default config;
