module.exports = (function () {
    const path = require('path');
    const HtmlWebpackPlugin = require('html-webpack-plugin');
    const webpack = require('webpack');

    return {
        entry: './index.js',
        mode: 'development',
        output: {
            path: path.resolve(__dirname, 'build'),
            filename: 'bundle.js'
        },
        devtool: 'source-map',
        devServer: {
            contentBase: './',
            hot: true,
            proxy: {
                "/api": "http://localhost:11000"
            }
        },
        module: {
            rules: [
                {
                    test: /\.js?$/,
                    exclude: /(node_modules)/,
                    loader: 'babel-loader',
                    options: {
                        presets: ["@babel/preset-env", "@babel/preset-react", "@babel/preset-flow"]
                    }
                },
                {
                    test: /\.css$/,
                    use: ['style-loader', 'css-loader']
                },
                {
                    test: /\.(png|jpg|gif)$/,
                    use: [
                        {
                            loader: 'file-loader',
                            options: {}
                        }
                    ]
                },
            ]
        },
        resolve: {
            alias: {
                models: path.resolve(__dirname, 'models/'),
                components: path.resolve(__dirname, 'components/'),
            }
        },
        plugins: [
            new webpack.ProgressPlugin(),
            new HtmlWebpackPlugin({
                title: 'Hot Module Replacement',
                template: './index.html',
            }),
            new webpack.HotModuleReplacementPlugin(),
        ]
    }
});