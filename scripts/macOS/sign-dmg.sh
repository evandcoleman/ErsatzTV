#! /bin/bash

SCRIPT_FOLDER=$(dirname ${BASH_SOURCE[0]})
REPO_ROOT="$SCRIPT_FOLDER/../.."

DMG_NAME="$REPO_ROOT/ErsatzTV.dmg"
ENTITLEMENTS="$SCRIPT_FOLDER/ErsatzTV.entitlements"
SIGNING_IDENTITY="1C6A49451D37647A54102A36B340F07638DAC95A"

codesign --force --timestamp --options=runtime --entitlements "$ENTITLEMENTS" --sign "$SIGNING_IDENTITY" "$DMG_NAME"
