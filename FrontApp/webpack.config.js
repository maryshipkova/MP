module.exports = function() {
  const path = require("path");
  const HtmlWebpackPlugin = require("html-webpack-plugin");
  const webpack = require("webpack");

  return {
    entry: "./index.js",
    mode: "development",
    output: {
      path: path.resolve(__dirname, "build"),
      filename: "bundle.js"
    },
    devtool: "source-map",
    devServer: {
      contentBase: "./",
      hot: true
    },
    module: {
      rules: [
        {
          test: /\.js?$/,
          exclude: /(node_modules)/,
          loader: "babel-loader",
          options: {
            presets: [
              "@babel/preset-env",
              "@babel/preset-react",
              "@babel/preset-flow"
            ]
          }
        },
        {
          test: /\.css$/,
          use: ["style-loader", "css-loader"]
        },
        {
          test: /\.(png|jpg|gif)$/,
          use: [
            {
              loader: "file-loader",
              options: {}
            }
          ]
        }
      ]
    },
    resolve: {
      alias: {
        models: path.resolve(__dirname, "models/"),
        components: path.resolve(__dirname, "components/"),
        types: path.resolve(__dirname, "types/"),
        constants: path.resolve(__dirname, "constants/")
      }
    },
    plugins: [
      new webpack.ProgressPlugin(),
      new HtmlWebpackPlugin({
        title: "Hot Module Replacement",
        template: "./index.html"
      }),
      new webpack.HotModuleReplacementPlugin()
    ]
  };
};
