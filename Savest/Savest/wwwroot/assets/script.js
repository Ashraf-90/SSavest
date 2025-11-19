// JavaScript for SaVest landing page
// Bootstrap is loaded via CDN in the HTML file

document.addEventListener('DOMContentLoaded', function() {
  // ===== Header Mobile Menu Toggle =====
  (function() {
    const navbarToggle = document.querySelector('.navbar-toggle');
    const navbarMenu = document.querySelector('.navbar-menu');
    const navLinks = document.querySelectorAll('.navbar-menu a');

    if (navbarToggle && navbarMenu) {
      navbarToggle.addEventListener('click', function() {
        this.classList.toggle('active');
        navbarMenu.classList.toggle('active');
        document.body.style.overflow = navbarMenu.classList.contains('active') ? 'hidden' : '';
      });

      // Close menu when clicking on a link
      navLinks.forEach(link => {
        link.addEventListener('click', function() {
          navbarToggle.classList.remove('active');
          navbarMenu.classList.remove('active');
          document.body.style.overflow = '';
        });
      });

      // Close menu when clicking outside
      document.addEventListener('click', function(e) {
        if (!navbarToggle.contains(e.target) && !navbarMenu.contains(e.target)) {
          navbarToggle.classList.remove('active');
          navbarMenu.classList.remove('active');
          document.body.style.overflow = '';
        }
      });
    }
  })();

  // Initialize hero slider background images
  const carouselItems = document.querySelectorAll('#heroCarousel .carousel-item');
  
  carouselItems.forEach((item, index) => {
    const bgImage = item.getAttribute('data-bg-image');
    if (bgImage) {
      item.style.backgroundImage = `url('${bgImage}')`;
    }
  });

  // Initialize Bootstrap Carousel with auto-play
  const heroCarousel = document.querySelector('#heroCarousel');
  if (heroCarousel) {
    const carousel = new bootstrap.Carousel(heroCarousel, {
      interval: 4000, // 4 seconds
      wrap: true,
      pause: 'hover' // Pause on hover
    });

    // Optional: Add fade transition effect
    heroCarousel.addEventListener('slide.bs.carousel', function () {
      const activeItem = this.querySelector('.carousel-item.active');
      if (activeItem) {
        activeItem.style.opacity = '0';
      }
    });

    heroCarousel.addEventListener('slid.bs.carousel', function () {
      const activeItem = this.querySelector('.carousel-item.active');
      if (activeItem) {
        activeItem.style.opacity = '1';
      }
    });
  }

  // Smooth scroll for anchor links
  document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
      const href = this.getAttribute('href');
      if (href !== '#' && href !== '') {
        e.preventDefault();
        const target = document.querySelector(href);
        if (target) {
          target.scrollIntoView({
            behavior: 'smooth',
            block: 'start'
          });
        }
      }
    });
  });


  // ===== Scroll animations for Reliable Protection section =====
  (function() {
    const reliableSection = document.getElementById('reliable');
    if (!reliableSection) return;

    const colLeft = reliableSection.querySelector('.col-left');
    const colText = reliableSection.querySelector('.col-text');

    function triggerAnimation() {
      // Add animation classes when section comes into view
      if (colLeft) {
        setTimeout(() => colLeft.classList.add('animate-in'), 100);
      }
      if (colText) {
        setTimeout(() => colText.classList.add('animate-in'), 200);
      }
    }

    // Check if section is already visible on page load
    const rect = reliableSection.getBoundingClientRect();
    const isVisible = rect.top < window.innerHeight && rect.bottom > 0;
    
    if (isVisible) {
      // If already visible, trigger animation after a short delay
      setTimeout(triggerAnimation, 300);
    }

    const observerOptions = {
      threshold: 0.2, // Trigger when 20% of the section is visible
      rootMargin: '0px'
    };

    const observer = new IntersectionObserver((entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          triggerAnimation();
          // Unobserve after animation triggers to prevent re-triggering
          observer.unobserve(entry.target);
        }
      });
    }, observerOptions);

    observer.observe(reliableSection);
  })();

  // ===== Service Section - Data Background Handler =====
  (function() {
    // Handle data-background attribute
    document.querySelectorAll("[data-background]").forEach(function(element) {
      const bgImage = element.getAttribute("data-background");
      if (bgImage) {
        element.style.backgroundImage = "url(" + bgImage + ")";
      }
    });
  })();

  // ===== Service Section - Swiper Slider =====
  (function() {
    const serviceSliderEl = document.querySelector('.dm-service-slider');
    if (!serviceSliderEl) return;

    const serviceSlider = new Swiper('.dm-service-slider', {
      spaceBetween: 0,
      slidesPerView: 4,
      roundLengths: true,
      loop: true,
      autoplay: {
        enabled: true,
        delay: 5000
      },
      speed: 400,
      breakpoints: {
        '1600': {
          slidesPerView: 4,
        },
        '1200': {
          slidesPerView: 3,
        },
        '992': {
          slidesPerView: 3,
        },
        '768': {
          slidesPerView: 2,
        },
        '576': {
          slidesPerView: 2,
        },
        '0': {
          slidesPerView: 1,
        },
      },
    });
  })();

  // ===== About Section - Scroll Animation =====
  (function() {
    const aboutSection = document.querySelector('.about-area');
    if (!aboutSection) return;

    // Only trigger animation when scrolling into view
    const observerOptions = {
      threshold: 0.2, // Trigger when 20% of the section is visible
      rootMargin: '0px'
    };

    const observer = new IntersectionObserver((entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          aboutSection.classList.add('animate-in');
          // Unobserve after animation triggers to prevent re-triggering
          observer.unobserve(entry.target);
        }
      });
    }, observerOptions);

    observer.observe(aboutSection);
  })();

  // ===== Products Section - Scroll Animation =====
  (function() {
    const productsSection = document.querySelector('.service-4');
    if (!productsSection) return;

    // Only trigger animation when scrolling into view
    const observerOptions = {
      threshold: 0.2, // Trigger when 20% of the section is visible
      rootMargin: '0px'
    };

    const observer = new IntersectionObserver((entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          productsSection.classList.add('animate-in');
          // Unobserve after animation triggers to prevent re-triggering
          observer.unobserve(entry.target);
        }
      });
    }, observerOptions);

    observer.observe(productsSection);
  })();

  // ===== About Section - Counter Animation =====
  (function() {
    const counterElements = document.querySelectorAll('.xbo');
    if (!counterElements.length) return;

    const observerOptions = {
      threshold: 0.5, // Trigger when 50% of element is visible
      rootMargin: '0px'
    };

    const observer = new IntersectionObserver((entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting && !entry.target.classList.contains('animated')) {
          const element = entry.target;
          element.classList.add('animated');
          
          const countNumber = parseInt(element.getAttribute('data-count')) || 0;
          const duration = 2000; // 2 seconds
          const steps = 60;
          const increment = countNumber / steps;
          let current = 0;

          const timer = setInterval(function() {
            current += increment;
            if (current >= countNumber) {
              element.textContent = countNumber;
              clearInterval(timer);
            } else {
              element.textContent = Math.floor(current);
            }
          }, duration / steps);
        }
      });
    }, observerOptions);

    counterElements.forEach(element => {
      observer.observe(element);
    });
  })();

  // ===== Who We Are Section - Scroll Animation =====
  (function() {
    const whoWeAreSection = document.querySelector('.service.innar-service');
    if (!whoWeAreSection) return;

    const titleElement = whoWeAreSection.querySelector('.who-we-are-title');
    const pointsElement = whoWeAreSection.querySelector('.who-we-are-points');

    function triggerAnimation() {
      // Add animation classes when section comes into view
      if (titleElement) {
        setTimeout(() => titleElement.classList.add('animate-in'), 100);
      }
      if (pointsElement) {
        setTimeout(() => pointsElement.classList.add('animate-in'), 200);
      }
    }

    // Check if section is already visible on page load
    const rect = whoWeAreSection.getBoundingClientRect();
    const isVisible = rect.top < window.innerHeight && rect.bottom > 0;
    
    if (isVisible) {
      // If already visible, trigger animation after a short delay
      setTimeout(triggerAnimation, 300);
    }

    const observerOptions = {
      threshold: 0.2, // Trigger when 20% of the section is visible
      rootMargin: '0px'
    };

    const observer = new IntersectionObserver((entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          triggerAnimation();
          // Unobserve after animation triggers to prevent re-triggering
          observer.unobserve(entry.target);
        }
      });
    }, observerOptions);

    observer.observe(whoWeAreSection);
  })();

  // ===== Our Story Section - Scroll Animation =====
  (function() {
    const ourStorySection = document.getElementById('our-story');
    if (!ourStorySection) return;

    const contentElement = ourStorySection.querySelector('.our-story-content');
    const imageElement = ourStorySection.querySelector('.our-story-image');

    function triggerAnimation() {
      // Add animation classes when section comes into view
      if (contentElement) {
        setTimeout(() => contentElement.classList.add('animate-in'), 100);
      }
      if (imageElement) {
        setTimeout(() => imageElement.classList.add('animate-in'), 200);
      }
    }

    // Check if section is already visible on page load
    const rect = ourStorySection.getBoundingClientRect();
    const isVisible = rect.top < window.innerHeight && rect.bottom > 0;
    
    if (isVisible) {
      // If already visible, trigger animation after a short delay
      setTimeout(triggerAnimation, 300);
    }

    const observerOptions = {
      threshold: 0.2, // Trigger when 20% of the section is visible
      rootMargin: '0px'
    };

    const observer = new IntersectionObserver((entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          triggerAnimation();
          // Unobserve after animation triggers to prevent re-triggering
          observer.unobserve(entry.target);
        }
      });
    }, observerOptions);

    observer.observe(ourStorySection);
  })();

  // ===== Footer Newsletter Form Handler =====
  (function() {
    const newsletterForm = document.querySelector('.footer-newsletter');
    if (!newsletterForm) return;

    const emailInput = newsletterForm.querySelector('input[type="email"]');
    const messageDiv = newsletterForm.querySelector('.newsletter-message');
    const submitBtn = newsletterForm.querySelector('.newsletter-submit-btn');

    function showMessage(text, isSuccess) {
      messageDiv.textContent = text;
      messageDiv.className = 'newsletter-message show ' + (isSuccess ? 'success' : 'error');
      
      // Hide message after 5 seconds
      setTimeout(() => {
        messageDiv.classList.remove('show');
        setTimeout(() => {
          messageDiv.textContent = '';
          messageDiv.className = 'newsletter-message';
        }, 300);
      }, 5000);
    }

    newsletterForm.addEventListener('submit', function(e) {
      e.preventDefault();
      const email = emailInput.value.trim();

      if (!email) {
        showMessage('Please enter a valid email address.', false);
        emailInput.focus();
        return;
      }

      // Validate email format
      const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
      if (!emailRegex.test(email)) {
        showMessage('Please enter a valid email address.', false);
        emailInput.focus();
        return;
      }

      // Disable button during submission
      submitBtn.disabled = true;
      submitBtn.style.opacity = '0.7';
      submitBtn.style.cursor = 'not-allowed';

      // Here you can add your newsletter subscription API call
      // Simulating API call with setTimeout
      setTimeout(() => {
        // Success
        showMessage('Thank you for subscribing! We will keep you updated.', true);
        emailInput.value = '';
        
        // Re-enable button
        submitBtn.disabled = false;
        submitBtn.style.opacity = '1';
        submitBtn.style.cursor = 'pointer';
      }, 1000);
    });
  })();
});

