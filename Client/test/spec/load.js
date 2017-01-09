/* global describe, before, it, expect */

describe('Initialization', function () {
  var frameWindow;

  before(function() {
    frameWindow = document.getElementById('app-frame').contentWindow;
  });

  it('should load', function () {
    expect(frameWindow.document.getElementById('content-container')).to.be.ok();
  });
});
