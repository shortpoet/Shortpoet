import { JSDOM } from "jsdom"
const dom = new JSDOM()
global.document = dom.window.document
global.window = dom.window

// import { config } from '@vue/test-utils'
// import $ from 'jquery'

// global.$ = global.jquery = $
// console.log($)


// config.mocks['$'] = $

// Object.defineProperty(window, '$', {value: $});
// Object.defineProperty(global, '$', {value: $});
// Object.defineProperty(global, 'jQuery', {value: $});

// global.window = window
// global.$ = require('jquery');

// window.$ = require('jquery');

// global['$'] = global['jQuery'] = $