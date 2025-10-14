import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeroFormUiComponent } from './hero-form-ui.component';

describe('HeroFormUiComponent', () => {
  let component: HeroFormUiComponent;
  let fixture: ComponentFixture<HeroFormUiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HeroFormUiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HeroFormUiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
