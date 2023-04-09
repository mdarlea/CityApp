import { SkipSelf, Optional, Host } from "@angular/core";
import { FormGroup, ControlContainer } from "@angular/forms";

export const containerFactory = (container: ControlContainer) => {
  if (!container) {
    throw new Error('I need a FormGroup instance');
  }

  return container;
};

export const parentFormGroupProvider = [
  {
    provide: ControlContainer,
    useFactory: containerFactory,
    deps: [[new Host(), new SkipSelf(), new Optional(), ControlContainer]],
  },
];
