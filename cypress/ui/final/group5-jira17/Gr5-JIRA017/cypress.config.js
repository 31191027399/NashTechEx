const { defineConfig } = require("cypress");
const createBundler = require("@bahmutov/cypress-esbuild-preprocessor");
const addCucumberPreprocessorPlugin =
  require("@badeball/cypress-cucumber-preprocessor").addCucumberPreprocessorPlugin;
const createEsbuildPlugin =
  require("@badeball/cypress-cucumber-preprocessor/esbuild").createEsbuildPlugin;
const { downloadFile } = require('cypress-downloadfile/lib/addPlugin');
const { verifyDownloadTasks } = require('cy-verify-downloads');
module.exports = defineConfig({
  env: {
    apiUrl: "https://api.unsplash.com",
  },
  e2e: {
    watchForFileChanges: false,
    baseUrl: "https://unsplash.com",
    async setupNodeEvents(on, config) {
      const bundler = createBundler({
        plugins: [createEsbuildPlugin(config)],
      });

      on("file:preprocessor", bundler);
      await addCucumberPreprocessorPlugin(on, config);
      on('task', { downloadFile });
      on('task', verifyDownloadTasks);
      return config;
    },
    specPattern: "cypress/e2e/ui/**/*.feature",
    viewportWidth: 1920,
    viewportHeight: 1080,
    supportFile: false
  },
});
