/*global describe, it  */
/*eslint-env node*/

var assert = require('assert');
import { dasherize, plural } from './string';

describe('String Utils', function() {
  'use strict';

  describe('#dasherize()', function () {
    it('should dasherize', function () {
      assert.equal(dasherize('fooBarBaz'), 'foo-bar-baz');
    });
  });

  describe('#plural()', function () {
    it('should pluralize', function () {
      assert.equal(plural(0, 'cat', 'cats'), 'cats');
      assert.equal(plural(1, 'cat', 'cats'), 'cat');
      assert.equal(plural(2, 'cat', 'cats'), 'cats');
    });
  });
});
