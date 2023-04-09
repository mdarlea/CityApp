import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateBoulevardComponent } from './create-boulevard.component';

describe('CreateBoulevardComponent', () => {
  let component: CreateBoulevardComponent;
  let fixture: ComponentFixture<CreateBoulevardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateBoulevardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateBoulevardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
