﻿import '../css/app.css';
import './signalRTurboStreamElement'

import * as Turbo from '@hotwired/turbo'

import { Application } from '@hotwired/stimulus'
import { definitionsFromContext } from '@hotwired/stimulus-webpack-helpers'

const application = Application.start();
const context = require.context('./controllers', true, /\.js$/);
application.load(definitionsFromContext(context));

// Turns Turbo Drive on/off (default on). 
// If off, we must opt-in to Turbo Drive on a per-link and per-form basis using data-turbo="true".
Turbo.session.drive = true

// Turbo event listeners
document.addEventListener('turbo:load', function (e) {
  console.log('turbo:load', e);
});

document.addEventListener('turbo:visit', function (e) {
  console.log('turbo:visit', e);
});

document.addEventListener('turbo:frame-load', function (e) {
  console.log('turbo:frame-load', e);
});