#!/usr/bin/env python3
# -*- coding: utf8 -*-

import os
from setuptools import _install_setup_requires, setup

# Utility function to read the README file.
# Used for the long_description.  It's nice, because now 1) we have a top level
# README file and 2) it's easier to type in the README file than to put a raw
# string in below ...


def read(fname):
    return open(os.path.join(os.path.dirname(__file__), fname)).read()


setup(
    name="mfrc522_i2c",
    description=("MFRC522 RFID reader/writer I2C driver in Python 3"),
    keywords="i2c rfid mfrc522",
    packages=['mfrc522_i2c'],
    long_description=read('README.md'),
    classifiers=[
        "Programming Language :: Python :: 3",
        "Operating System :: OS Independent",
        "Development Status :: 3 - Alpha",
        "Topic :: Utilities",
        "License :: OSI Approved :: GNU General Public License v3 (GPLv3)"
    ],
    install_requires=[
        "smbus==1.1.post2"
    ]
)
