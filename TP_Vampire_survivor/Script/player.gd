extends CharacterBody2D

@onready var animSprite: AnimatedSprite2D = $AnimatedSprite2D


const SPEED = 120.0

func Save() -> Dictionary:
	var saved_datas : Dictionary = {
		"filename" : get_path(),
		"posX" : position.x,
		"posY" : position.y,
		"flipH" : animSprite.flip_h
	}
	return saved_datas
	
func Load(datas: Dictionary) -> void:
	position.x = datas["posX"]
	position.y = datas["posY"]
	animSprite.flip_h = datas["flipH"]

func _physics_process(delta: float) -> void:

	var HDirection := Input.get_axis("left", "right")
	var VDirection := Input.get_axis("up", "down")
	var dir := Vector2(HDirection, VDirection).normalized()
		
	if HDirection < 0:
		animSprite.play("side_walk")
		animSprite.flip_h = true	
	elif HDirection > 0 : 
		animSprite.play("side_walk")
		animSprite.flip_h = false
	elif VDirection > 0:
		animSprite.play("down_walk")
	elif VDirection < 0:
		animSprite.play("up_walk")
	else:
		animSprite.play("idle")
	
	if dir != Vector2.ZERO:
		velocity = dir * SPEED	
		
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
		velocity.y = move_toward(velocity.y, 0, SPEED)

	move_and_slide()
